<script setup>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import VaultCard from "@/components/VaultCard.vue";
import KeepCard from "@/components/KeepCard.vue";
import EditAccountModal from "@/components/EditAccountModal.vue";
import Pop from "@/utils/Pop.js";
import { logger } from "@/utils/Logger.js";
import { useRoute } from "vue-router";
import { keepsService } from "@/services/KeepsService.js";
import { vaultsService } from "@/services/VaultsService.js";

const account = computed(() => AppState.account)
const keeps = computed(() => AppState.keeps)
const vautls = computed(() => AppState.vaults)
const route = useRoute()

onMounted(() => {
  // getMyKeeps()
  getMyVaults()
})

async function getMyVaults() {
  try {
    await vaultsService.getMyVaults()
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

// async function getMyKeeps() {
//   try {
//     const profileId = route.params.profileId
//     await keepsService.getMyKeeps(profileId)
//   }
//   catch (error) {
//     Pop.meow(error);
//     logger.error(error)
//   }
// }

</script>

<template>
  <div v-if="account">
    <section class="container">
      <div class="row justify-content-center">
        <div class="col-md-8">
          <div class="mt-5">
            <img :src="account.coverImg" :alt="'A cover image by ' + account.name" class="cover-img">
            <div class="text-end dropdown">
              <button class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false"
                title="Dropdown menu">
                <i class="mdi mdi-dots-horizontal fs-4"></i>
              </button>
              <ul class="dropdown-menu">
                <li role="button" class="dropdown-item" data-bs-toggle="modal" data-bs-target="#editAccountModal"
                  title="Edit Account">edit account</li>
              </ul>
            </div>
            <div class="text-center">
              <img :src="account.picture" :alt="'A picture of ' + account.name" class="account-img account-sticky">
            </div>
            <div class="text-center">
              <h1 class="mb-3 fw-bold">{{ account.name }}</h1>
              <p>{{ vautls.length }} Vaults | {{ keeps.length }} Keeps</p>
            </div>
          </div>
        </div>
        <EditAccountModal />
      </div>

      <!-- SECTION vaults -->
      <div class="row justify-content-around">
        <div class="col-md-9">
          <div class="mt-3">
            <h2 class="mb-3 fw-bold">Vaults</h2>
          </div>
          <div class="row justify-content-center">
            <div class="col-md-3">
              <!-- <VaultCard :vault="vault"/> -->
            </div>
          </div>
        </div>

        <!-- SECTION keeps -->
        <div class="col-md-9">
          <div class="mt-3">
            <h2 class="mb-3 fw-bold">Keeps</h2>
          </div>
          <div class="masonry-container">
            <div class="mb-3">
              <!-- <KeepCard :keep="keep"/> -->
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
  <div v-else>
    <h1>Loading... <i class="mdi mdi-loading mdi-spin"></i></h1>
  </div>
</template>

<style scoped lang="scss">
.cover-img {
  width: 100%;
  height: 400px;
  object-fit: cover;
  object-position: center;
  border-radius: 9px;
}

.account-img {
  height: 7rem;
  border-radius: 50%;
  aspect-ratio: 1/1;
  object-fit: cover;
  object-position: center;
  border: 1px solid rgb(100, 97, 97);
  box-shadow: 5px 5px 8px rgba(0, 0, 0, 0.2), 5px 6px 4px rgba(0, 0, 0, 0.16);
}

.masonry-container {
  columns: 200px;

  >* {
    break-inside: avoid;
    display: inline-block;
    width: 100%;
    height: auto;
  }
}

@media screen and (min-width: 768px) {
  .account-sticky {
    position: relative;
    bottom: 7em;
  }
}
</style>
