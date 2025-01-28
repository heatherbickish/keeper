import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { VaultKeep } from "@/models/VaultKeep.js"
import { AppState } from "@/AppState.js"

class VaultKeepsService {
  async createVaultKeep(vaultKeepData) {
    const response = await api.post('api/vaultkeeps', vaultKeepData)
    const vaultKeep = new VaultKeep(response.data)
    AppState.vaultKeeps.push(vaultKeep)
    AppState.activeKeep.kept += 1
  }

}

export const vaultKeepsService = new VaultKeepsService()