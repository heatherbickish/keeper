<script setup>
import Navbar from './components/Navbar.vue';
import { AppState } from './AppState.js';
import NewKeepModal from "./components/NewKeepModal.vue";
import NewVaultModal from "./components/NewVaultModal.vue";
import KeepModal from "./components/KeepModal.vue";

</script>

<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
    <KeepModal />
  </main>
  <footer>

  </footer>
  <NewKeepModal />
  <NewVaultModal />
</template>

<style lang="scss">
@import '@/assets/scss/main.scss';

:root {
  --main-height: calc(100vh - 32px - 64px);
}
</style>
