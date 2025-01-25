<script setup>
// import { onMounted, ref } from 'vue';
// import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';

// const theme = ref(loadState('theme') || 'light')

// onMounted(() => {
//   document.documentElement.setAttribute('data-bs-theme', theme.value)
// })

// function toggleTheme() {
//   theme.value = theme.value == 'light' ? 'dark' : 'light'
//   document.documentElement.setAttribute('data-bs-theme', theme.value)
//   saveState('theme', theme.value)
// }

</script>

<template>
  <nav class="px-3">
    <div class="d-flex align-items-center justify-content-between">
      <router-link :to="{ name: 'Home' }">
        <div class="d-flex align-items-center mt-2 ms-4 text-dark">
          <h5 class="rounded px-2 py-1">Home</h5>
          <button class="btn fs-5 mb-2 ms-2">Create</button>
        </div>
      </router-link>
      <div class="mt-2">
        <Login />
      </div>
    </div>
    <!-- <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button> -->
    <!-- <div class="collapse navbar-collapse" id="navbarText"> -->
    <!-- <ul class="navbar-nav me-auto">
        <li>
          <router-link :to="{ name: 'About' }" class="btn text-success lighten-30 selectable text-uppercase">
            About
          </router-link>
        </li>
      </ul> -->
    <!-- LOGIN COMPONENT HERE -->
    <!-- <div>
        <button class="btn text-light" @click="toggleTheme"
          :title="`Enable ${theme == 'light' ? 'dark' : 'light'} theme.`">
          <Icon :name="theme == 'light' ? 'weather-sunny' : 'weather-night'" />
        </button>
      </div> -->
    <!-- </div> -->

  </nav>
</template>

<style scoped>
h5 {
  background-color: #c3c8db;
}

nav {
  border-bottom: 2px solid #c3c8db;
}

/* a:hover {
  text-decoration: none;
} */

/* .nav-link {
  text-transform: uppercase;
} */

/* .navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
} */

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}
</style>
