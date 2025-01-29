<script setup>
import { AppState } from "@/AppState";
import VaultKeepCard from "@/components/VaultKeepCard.vue";
import { router } from "@/router";
import { keepsService } from "@/services/KeepsService";
import { vaultsService } from "@/services/VaultsService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { computed, onMounted } from "vue";
import { useRoute } from "vue-router";


const route = useRoute()
const vault = computed(() => AppState.activeVault)
const keptKeeps = computed(() => AppState.keptKeeps)


onMounted(() => {
  getVaultById()
  getKeepsByVaultId()
})

async function getVaultById() {
  try {
    const vaultId = route.params.vaultId
    await vaultsService.getVaultById(vaultId)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
    router.push({ name: 'Home' })
  }
}

async function getKeepsByVaultId() {
  try {
    const vaultId = route.params.vaultId
    await keepsService.getKeepsByVaultId(vaultId)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

</script>


<template>
  <div v-if="vault">
    <section class="container">
      <div class="row justify-content-center">
        <div class="col-md-6">
          <div class="mt-4">
            <div :style="{ backgroundImage: `url(${vault.img})` }" class="vault-img">
              <div class="text-center vault-info mb-5">
                <h1 class="mb-2">{{ vault.name }}</h1>
                <h4>by {{ vault.creator.name }}</h4>
              </div>
            </div>
            <div class="text-center mt-4">
              <span class="rounded px-1 py-1">{{ keptKeeps.length }} Keeps</span>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-12">
        <div class="masonry-container">
          <div v-for="keptKeep in keptKeeps" :key="keptKeep.id" class="mb-3 mx-2">
            <VaultKeepCard :keptKeep="keptKeep" />
          </div>
        </div>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped>
.vault-img {
  width: 100%;
  height: 400px;
  background-size: cover;
  background-position: center;
  border-radius: 9px;
  position: relative;
}

.vault-info {
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
}

h1 {
  font-size: 80px;
  color: rgb(238, 233, 233);
  text-shadow: 1px 1.2px rgb(61, 59, 59);
}

h4 {
  text-shadow: 1px 1.2px rgb(61, 59, 59);
  color: rgb(238, 233, 233);
}

span {
  background-color: #c3c8db;
  font-size: 30px;
  font-weight: 500;
  color: rgb(17, 17, 17)
}

.masonry-container {
  columns: 250px;

  >* {
    break-inside: avoid;
    display: inline-block;
    width: 100%;
    height: auto;
  }
}
</style>