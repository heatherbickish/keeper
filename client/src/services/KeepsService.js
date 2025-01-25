import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"
import { logger } from "@/utils/Logger.js"

class KeepsService {
  async getKeepById(keepId) {
    const response = await api.get(`api/keeps/${keepId}`)
    logger.log('got keep by id', response.data)
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