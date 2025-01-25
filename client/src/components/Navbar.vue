<script setup>
import Login from './Login.vue';


</script>

<template>
  <nav class="px-3">
    <div class="d-flex align-items-center justify-content-between">
      <router-link :to="{ name: 'Home' }">
        <div class="d-flex align-items-center mt-2 ms-4 text-dark">
          <h5 class="rounded px-2 py-1">Home</h5>
          <div class="dropdown">
            <button class="btn fs-5 mb-2 ms-2 dropdown-toggle" type="button" data-bs-toggle="dropdown"
              aria-expanded="false">
              Create
            </button>
            <ul class="dropdown-menu">
              <li class="dropdown-item fs-5">new keep</li>
              <hr>
              <li class="dropdown-item fs-5">new vault</li>
            </ul>
          </div>
        </div>
      </router-link>
      <div class="border border-1 mt-2">
        <p>the keepr co.</p>
      </div>
      <div class="mt-2">
        <Login />
      </div>
    </div>
  </nav>
</template>

<style scoped>
h5 {
  background-color: #c3c8db;
}

nav {
  border-bottom: 2px solid #c3c8db;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}
</style>
