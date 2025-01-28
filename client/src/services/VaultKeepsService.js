import { api } from "./AxiosService.js"
import { VaultKeep } from "@/models/VaultKeep.js"
import { AppState } from "@/AppState.js"
import { KeptKeep } from "@/models/KeptKeep.js"

class VaultKeepsService {
  async deleteVaultKeep(vaultKeepId) {
    const response = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
    const keptKeepsIndex = AppState.keptKeeps.findIndex(keptKeep => keptKeep.vaultKeepId == vaultKeepId)
    AppState.keptKeeps.splice(keptKeepsIndex, 1)
  }
  async createVaultKeep(vaultKeepData) {
    const response = await api.post('api/vaultkeeps', vaultKeepData)
    const vaultKeep = new VaultKeep(response.data)
    AppState.vaultKeeps.push(vaultKeep)
    AppState.activeKeep.kept++
  }

}

export const vaultKeepsService = new VaultKeepsService()