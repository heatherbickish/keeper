<script setup>
import { AppState } from "@/AppState";
import VaultCard from "@/components/VaultCard.vue";
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
              <p>2 Vaults | 68 Keeps</p>
            </div>
          </div>
        </div>
      </div>
      <div class="row justify-content-around">
        <div class="col-md-9">
          <div class="mt-3">
            <h3 class="mb-3">Vaults</h3>
          </div>
          <div class="row justify-content-around">
            <div v-for="vault in vaults" :key="vault.id" class="col-md-3">
              <VaultCard :vault="vault" />
            </div>
          </div>
        </div>
        <div class="col-md-9">
          <div>
            <h4>Keeps</h4>
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
  height: 6rem;
  border-radius: 50%;
  aspect-ratio: 1/1;
  border: 1px solid rgb(100, 97, 97);
}

@media screen and (min-width: 768px) {
  .creator-sticky {
    position: relative;
    bottom: 3em;
  }
}
</style>