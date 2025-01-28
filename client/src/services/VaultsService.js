import { api } from "./AxiosService.js"
import { Vault } from "@/models/Vault.js"
import { AppState } from "@/AppState.js"

class VaultsService {
  async getVaultById(vaultId) {
    AppState.activeVault = null
    const response = await api.get(`api/vaults/${vaultId}`)
    const vault = new Vault(response.data)
    AppState.activeVault = vault
  }
  async deleteVault(vaultId) {
    const response = await api.delete(`api/vaults/${vaultId}`)
    const vaultIndex = AppState.vaults.findIndex(vault => vault.id == vaultId)
    AppState.vaults.splice(vaultIndex, 1)
  }
  async createVault(vaultData) {
    const response = await api.post('api/vaults', vaultData)
    const createdVault = new Vault(response.data)
    // if (vaultData.creatorId != AppState.activeProfile.id) return
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