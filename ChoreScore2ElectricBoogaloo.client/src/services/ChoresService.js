import { AppState } from "../AppState.js"
import { Chore } from "../models/Chore.js"
import { api } from "./AxiosService.js"

class ChoresService {
  async getChores() {
    const chores = await api.get('/api/chores')
    AppState.chores = chores.data.map(c => new Chore(c))
  }

  setActiveChore(chore) {
    AppState.activeChore = new Chore(chore)
  }

  async AddOrEditEvent(choreData) {
    console.log(choreData)
  }
}

export const choresService = new ChoresService()