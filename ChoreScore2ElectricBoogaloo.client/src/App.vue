<template>
  <header>
    <Navbar />
  </header>
  <main class="position-relative">
    <router-view />
    <div class="position-absolute add-button">
      <button data-bs-toggle="modal" data-bs-target="#choreModal" class="btn btn-primary rounded-circle p-2 d-flex justify-content-center align-items-center"><i class="mdi mdi-plus-thick"></i></button>
    </div>
  </main>
   <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
  </footer>
  <div class="modal fade" id="choreModal" tabindex="-1" aria-labelledby="choreModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="choreModalLabel">Modal title</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <ChoreForm />
        </div>
      </div>
    </div>
  </div>
  <!-- TODO create separate modal for edit and create -->
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import ChoreForm from './components/ChoreForm.vue'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, ChoreForm }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}

.add-button {
  bottom: 15px;
  right: 15px;
  button {
    width: 2.5rem;
    height: 2.5rem;
  }
}
</style>
