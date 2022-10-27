<template>
  <div class="col-5 card p-3 rounded">
    <div class="row">
      <div class="col-1 d-flex justify-content-center align-items-center">
        <input v-if="chore.isComplete" checked disabled type="checkbox" class="w-100 h-100">
        <input v-else @change="finishChore(chore.id)" type="checkbox" class="w-100 h-100">
      </div>
      <div class="col-11">
        <div class="d-flex justify-content-between align-items-center">
          <div>
            <h3 v-if="!chore.isComplete" class="text-info">{{chore.name}}</h3>
            <h3 v-else class="text-special"><del>{{chore.name}}</del></h3>
          </div>
          <div class="d-flex gap-2">
            <button v-if="!chore.isComplete" @click="setActiveChore(chore)" data-bs-toggle="modal" data-bs-target="#editChoreModal" class="btn btn-outline-danger py-1 px-2"><i class="mdi mdi-pencil"></i></button> <!-- add data bs toggle for modal form -->
            <button v-else disabled class="btn btn-outline-danger py-1 px-2"><i class="mdi mdi-pencil"></i></button> <!-- add data bs toggle for modal form -->
            <button @click="deleteChore(chore.id)" class="btn btn-outline-danger py-1 px-2"><i class="mdi mdi-delete-forever"></i></button> <!-- TODO make delete button work -->
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { Chore } from '../models/Chore.js';
import { choresService } from '../services/ChoresService.js';
import Pop from '../utils/Pop.js';

export default {
  props: {
    chore: {type: Chore, required: true}
  },
  setup(){
    return {
      async setActiveChore(chore){
        try {
          choresService.setActiveChore(chore)
        } catch (error) {
          Pop.error(error, '[Setting Active Chore]')
        }
      },
      async finishChore(id) {
        try {
          console.log('Testing finish chore' + id)
          // TODO make finish chore work
          await choresService.finishChore(id)
        } catch (error) {
          Pop.error(error, '[Finishing Chore]')
        }
      },
      async deleteChore(id) {
        try {
          console.log('Testing deleting chore' + id)
          // TODO make finish chore work
          await choresService.deleteChore(id)
        } catch (error) {
          Pop.error(error, '[Deleting Chore]')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
h1, h2, h3, h4, h5, h6, p {
  font-family: 'Averia Libre', cursive;
  margin-bottom: 0;
}

.text-special {
  color: rgb(25, 120, 25)
}
</style>