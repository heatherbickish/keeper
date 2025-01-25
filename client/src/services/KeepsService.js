import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"

class KeepsService {
  async getAllKeeps() {
    const response = await api.get('api/keeps')
    const keeps = response.data.map(keep => new Keep(keep))
    AppState.keeps = keeps
  }

}

export const keepsService = new KeepsService()