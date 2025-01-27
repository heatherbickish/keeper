import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"
import { logger } from "@/utils/Logger.js"

class KeepsService {
  // async getMyKeeps(profileId) {
  //   const response = await api.get(`api/${profileId}/keeps`)
  //   logger.log(response.data)
  // }
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
    const response = await api.get(`api/keeps/${keepId}`)
    const keep = new Keep(response.data)
    AppState.activeKeep = keep
  }
  async getAllKeeps() {
    const response = await api.get('api/keeps')
    const keeps = response.data.map(keep => new Keep(keep))
    AppState.keeps = keeps
  }

}

export const keepsService = new KeepsService()