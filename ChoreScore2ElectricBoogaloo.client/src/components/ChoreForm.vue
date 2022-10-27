<template>
  <form @submit.prevent="handleSubmit()">
    <div class="row">
      <div class="form-floating mb-3 col-12">
        <input type="text" class="form-control" id="nameInput" placeholder="Chore Name" v-model="editable.name">
        <label for="nameInput">Chore Name</label>
      </div>
      <div class="d-flex justify-content-end col-12">
        <button type="submit" class="btn btn-secondary w-25 py-1 px-0">Submit</button>
      </div>
    </div>
  </form>
</template>


<script>
import { ref, watchEffect } from 'vue'
import { AppState } from '../AppState.js'
import { choresService } from '../services/ChoresService.js'
import Pop from '../utils/Pop.js'

export default {
  setup(){
    const editable = ref({})
    watchEffect(() => {
      editable.value = { ...AppState.activeChore }
    })
    return {
      editable,
      async handleSubmit() {
        try {
          choresService.AddOrEditEvent(editable.value)
        } catch (error) {
          Pop.error(error, "[Handling Submit]")
        }
      }
    }
  }
}
</script>
<style lang="scss" scoped>

</style>