<script setup>
import { AppState } from "@/AppState";
import { Vault } from "@/models/Vault";
import { computed } from "vue";


defineProps({
  vault: { type: Vault, required: true }
})

const account = computed(() => AppState.account)

</script>


<template>
  <div>
    <div :style="{ backgroundImage: `url(${vault.img})` }" class="vault-card mb-3">
      <div v-if="vault.creatorId == account?.id" class="text-end">
        <button class="btn" type="button" title="Delete Vault"><i class="mdi mdi-close-circle text-danger"></i></button>
      </div>
      <router-link :to="{ name: 'Vault', params: { vaultId: vault.id } }">
        <div class="vault-info d-flex justify-content-between align-items-center p-2">
          <h5 class="text-uppercase">{{ vault.name }}</h5>
          <i v-if="vault.isPrivate" class="mdi mdi-lock-check-outline fs-5"></i>
        </div>
      </router-link>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.vault-card {
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

.vault-info {
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
}
</style>