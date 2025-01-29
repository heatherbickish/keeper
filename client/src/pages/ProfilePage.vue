<script setup>
import { AppState } from "@/AppState";
import KeepCard from "@/components/KeepCard.vue";
import VaultCard from "@/components/VaultCard.vue";
import { keepsService } from "@/services/KeepsService";
import { profilesService } from "@/services/ProfilesService";
import { vaultsService } from "@/services/VaultsService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { computed, onMounted } from "vue";
import { useRoute } from "vue-router";


const route = useRoute()
const profile = computed(() => AppState.activeProfile)
const keeps = computed(() => AppState.keeps)
const vaults = computed(() => AppState.vaults)

onMounted(() => {
  GetProfileById()
  GetVaultsByProfileId()
  GetKeepsByProfileId()
})

async function GetProfileById() {
  try {
    const profileId = route.params.profileId
    await profilesService.GetProfileById(profileId)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

async function GetVaultsByProfileId() {

  try {
    const profileId = route.params.profileId
    await vaultsService.GetVaultsByProfileId(profileId)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

async function GetKeepsByProfileId() {
  try {
    const profileId = route.params.profileId
    await keepsService.GetKeepsByProfileId(profileId)

  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

</script>


<template>
  <div v-if="profile">
    <section class="container">
      <div class="row justify-content-center">
        <div class="col-md-8 ">
          <div class="mt-5">
            <img :src="profile.coverImg" :alt="'A cover image by ' + profile.name" class="cover-img">
            <div class="text-center">
              <img :src="profile.picture" :alt="'A picture of ' + profile.name" class="creator-img  creator-sticky">
            </div>
            <div class="text-center">
              <h1>{{ profile.name }}</h1>
              <p>{{ vaults.length }} Vaults | {{ keeps.length }} Keeps</p>
            </div>
          </div>
        </div>
      </div>

      <!-- SECTION vaults -->
      <div class="row justify-content-around">
        <div class="col-md-9">
          <div class="mt-3">
            <h2 class="mb-3 fw-bold">Vaults</h2>
          </div>
          <div class="row justify-content-center">
            <div v-for="vault in vaults" :key="vault.id" class="col-md-3">
              <VaultCard :vault="vault" />
            </div>
          </div>
        </div>

        <!-- SECTION keeps -->
        <div class="col-md-9">
          <div class="mt-3">
            <h2 class="mb-3 fw-bold">Keeps</h2>
          </div>
          <div class="masonry-container">
            <div v-for="keep in keeps" :key="keep.id" class="mb-3">
              <KeepCard :keep="keep" />
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>

</template>


<style lang="scss" scoped>
.cover-img {
  width: 100%;
  height: 400px;
  object-fit: cover;
  object-position: center;
  border-radius: 9px;
}

.creator-img {
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

@media screen and (max-width:768px) {
  .masonry-container {
    columns: 2;
  }
}

@media screen and (min-width: 768px) {
  .creator-sticky {
    position: relative;
    bottom: 4em;
  }
}
</style>