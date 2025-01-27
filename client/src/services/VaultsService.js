import { api } from "./AxiosService.js"
import { Vault } from "@/models/Vault.js"
import { AppState } from "@/AppState.js"
import { logger } from "@/utils/Logger.js"

class VaultsService {
  async createVault(vaultData) {
    const response = await api.post('api/vaults', vaultData)
    const createdVault = new Vault(response.data)
    if (vaultData.creatorId != AppState.activeProfile.id) return
    AppState.vaults.unshift(createdVault)
  }
  async getMyVaults() {
    const response = await api.get('account/vaults')
    const vaults = response.data.map(vault => new Vault(vault))
    AppState.vaults = vaults

  }
  async GetVaultsByProfileId(profileId) {
    const response = await api.get(`api/profiles/${profileId}/vaults`)
    const vaults = response.data.map(vault => new Vault(vault))
    AppState.vaults = vaults
  }

}

export const vaultsService = new VaultsService()