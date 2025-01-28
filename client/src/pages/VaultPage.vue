<script setup>
import { AppState } from "@/AppState";
import { router } from "@/router";
import { keepsService } from "@/services/KeepsService";
import { vaultsService } from "@/services/VaultsService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { computed, onMounted } from "vue";
import { useRoute } from "vue-router";


const route = useRoute()
const vault = computed(() => AppState.activeVault)
const keeps = computed(() => AppState.keeps)


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
          <div class="mt-5">
            <div :style="{ backgroundImage: `url(${vault.img})` }" class="vault-img">
              <div class="text-center vault-info mb-5">
                <h1 class="mb-2">{{ vault.name }}</h1>
                <h3>by {{ vault.creator.name }}</h3>
              </div>
            </div>
            <div class="text-center mt-4">
              <span class="rounded px-1 py-1">{{ keeps.length }} Keeps</span>
            </div>
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
  font-size: 100px;
  color: rgb(238, 233, 233);
  text-shadow: 1px 1.2px rgb(61, 59, 59);
}

h3 {
  text-shadow: 1px 1.2px rgb(61, 59, 59);
  color: rgb(238, 233, 233);
}

span {
  background-color: #c3c8db;
  font-size: 30px;
  font-weight: 500;
  color: rgb(17, 17, 17)
}
</style>