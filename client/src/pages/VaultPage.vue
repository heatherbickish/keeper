<script setup>
import { vaultsService } from "@/services/VaultsService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { onMounted } from "vue";
import { useRoute } from "vue-router";


const route = useRoute()

onMounted(() => {
  getVaultById()
})

async function getVaultById() {
  try {
    const vaultId = route.params.vaultId
    await vaultsService.getVaultById(vaultId)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

</script>


<template>
  <h1>Vault page</h1>
</template>


<style lang="scss" scoped></style>