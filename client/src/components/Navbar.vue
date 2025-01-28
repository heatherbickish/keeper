<script setup>
import { computed } from "vue";
import Login from './Login.vue';
import { AppState } from "@/AppState";
import { useRoute } from "vue-router";

const route = useRoute()
const account = computed(() => AppState.account)
const profile = computed(() => AppState.activeProfile)
const profileId = route.params.profileId
</script>

<template>
  <nav class="px-3">
    <div class="d-flex align-items-center justify-content-between">
      <div class="d-flex align-items-center mt-2 ms-4 text-dark">
        <router-link :to="{ name: 'Home' }">
          <h5 class="rounded px-2 py-1">Home</h5>
        </router-link>
        <div v-if="account" class="dropdown">
          <button class="btn fs-5 mb-2 ms-2 dropdown-toggle" type="button" data-bs-toggle="dropdown"
            aria-expanded="false" title="Dropdown menu">
            Create
          </button>
          <ul class="dropdown-menu">
            <li role="button" class="dropdown-item fs-5" data-bs-toggle="modal" data-bs-target="#newKeepModal"
              title="Create New Keep">new
              keep</li>
            <hr>
            <li role="button" class="dropdown-item fs-5" data-bs-toggle="modal" data-bs-target="#newVaultModal"
              title="Create New Vault">new
              vault</li>
          </ul>
        </div>
      </div>
      <div class="border border-1 mt-2 pt-2">
        <p class="text-center">the keepr co.</p>
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
  text-decoration: none;
  color: rgb(17, 17, 17)
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
