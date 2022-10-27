import { AppState } from "../AppState.js"
import { Chore } from "../models/Chore.js"
import Pop from "../utils/Pop.js"
import { api } from "./AxiosService.js"

class ChoresService {
  async getChores() {
    const chores = await api.get('/api/chores')
    AppState.chores = chores.data.map(c => new Chore(c))
  }

  setActiveChore(chore) {
    AppState.activeChore = new Chore(chore)
  }

  async AddChore(choreData) {
    console.log("Adding Chore: ")
    console.log(choreData)
    const chore = await api.post('/api/chores', choreData)
    AppState.chores.push(new Chore(chore.data))
  }
  
  async EditChore(choreData) {
    console.log("Editing Chore: ")
    console.log(choreData)
    const chore = await api.put(`api/chores/${choreData.id}`, {name: choreData.name})
    const choreIndex = AppState.chores.findIndex(c => c.id == choreData.id)
    AppState.chores[choreIndex] = new Chore(chore.data)
  }

  async finishChore(id) {
    const chore = await api.put(`/api/chores/${id}/complete`)
    const choreIndex = AppState.chores.findIndex(c => c.id == id)
    AppState.chores[choreIndex] = new Chore(chore.data)
  }
  
  async deleteChore(id) {
    const chore = await api.delete(`/api/chores/${id}`)
    const choreIndex = AppState.chores.findIndex(c => c.id == id)
    AppState.chores.splice(choreIndex, 1)
    Pop.toast('Chore has been terminated', "success", 'top')
  }
}

export const choresService = new ChoresService()