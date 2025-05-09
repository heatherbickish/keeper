import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"
import { logger } from "@/utils/Logger.js"
import { KeptKeep } from "@/models/KeptKeep.js"

class KeepsService {

  async getKeepsByVaultId(vaultId) {
    AppState.keeps = []
    const response = await api.get(`api/vaults/${vaultId}/keeps`)
    AppState.keptKeeps = response.data.map(keep => new KeptKeep(keep))
  }
  async getMyKeeps(accountId) {
    const response = await api.get(`api/profiles/${accountId}/keeps`)
    const keeps = response.data.map(keep => new Keep(keep))
    AppState.keeps = keeps
  }
  async deleteKeep(keepId) {
    const response = await api.delete(`api/keeps/${keepId}`)
    const keepIndex = AppState.keeps.findIndex(keep => keep.id == keepId)
    AppState.keeps.splice(keepIndex, 1)
  }
  async createKeep(keepData) {
    const response = await api.post('api/keeps', keepData)
    const createdKeep = new Keep(response.data)
    AppState.keeps.unshift(createdKeep)
  }
  async GetKeepsByProfileId(profileId) {
    const response = await api.get(`api/profiles/${profileId}/keeps`)
    const keeps = response.data.map(keep => new Keep(keep))
    AppState.keeps = keeps
  }
  async getKeepById(keepId) {
    AppState.activeKeep = null
    const response = await api.get(`api/keeps/${keepId}`)
    const keep = new Keep(response.data)
    AppState.activeKeep = keep
  }
  async getAllKeeps() {
    AppState.keeps = []
    const response = await api.get('api/keeps')
    const keeps = response.data.map(keep => new Keep(keep))
    AppState.keeps = keeps
  }

}

export const keepsService = new KeepsService()