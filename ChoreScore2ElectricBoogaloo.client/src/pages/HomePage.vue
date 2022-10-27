<template>
  <section class="container-fluid">
    <div v-if="chores" class="row p-3 gap-3 justify-content-center">
      <ChoreCard v-for="c in chores" :chore="c" />
    </div>
  </section>
</template>

<script>
import { onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { choresService } from '../services/ChoresService.js'
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import ChoreCard from '../components/ChoreCard.vue';

export default {
  setup() {
    async function getChores() {
      try {
        await choresService.getChores()
      } catch (error) {
        Pop.error(error)
      }
    }
    onMounted(()=>{
      getChores();
    })
    return {
      chores: computed(()=> AppState.chores)
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
