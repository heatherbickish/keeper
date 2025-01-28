<script setup>
import { KeptKeep } from "@/models/KeptKeep";
import VaultKeepModal from "./VaultKeepModal.vue";
import { computed } from "vue";
import { AppState } from "@/AppState";
import Pop from "@/utils/Pop";
import { logger } from "@/utils/Logger";
import { vaultKeepsService } from "@/services/VaultKeepsService";
import { keepsService } from "@/services/KeepsService";

const account = computed(() => AppState.account)

const props = defineProps({
  keptKeep: { type: KeptKeep, required: true }
})

async function deleteVaultKeep(vaultKeepId) {
  try {
    const yes = await Pop.confirm(`Are you sure you want to delete ${props.keptKeep.name} from this vault?`)
    if (!yes) return
    await vaultKeepsService.deleteVaultKeep(vaultKeepId)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

async function getKeptKeepById(keptKeepId) {
  try {
    await keepsService.getKeepById(keptKeepId)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

</script>


<template>
  <div class="mt-5">
    <div :style="{ backgroundImage: `url(${keptKeep.img})` }" class="kept-card">
      <div class="text-end">
        <button @click="deleteVaultKeep(keptKeep.vaultKeepId)" class="btn" type="button" title="Delete from vault"><i
            class="mdi mdi-close-circle text-danger"></i></button>
      </div>
      <div class="kept-info">
        <h5 @click="getKeptKeepById(keptKeep.id)" class="text-uppercase ms-3" data-bs-toggle="modal"
          data-bs-target="#vaultKeepModal" role="button">{{
            keptKeep.name }}</h5>
      </div>
    </div>
  </div>
  <VaultKeepModal />
</template>


<style lang="scss" scoped>
.kept-card {
  width: auto;
  height: 150px;
  background-size: cover;
  background-position: center;
  border-radius: 9px;
  box-shadow: 0 5px 8px rgba(0, 0, 0, 0.2), 5px 6px 4px rgba(0, 0, 0, 0.16);
  position: relative;
}

h5,
i {
  text-shadow: 1px 1px rgb(43, 41, 41);
  font-weight: 400;
  color: rgb(250, 240, 240);
}

.kept-info {
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
}
</style>