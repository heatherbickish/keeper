<script setup>
import { KeptKeep } from "@/models/KeptKeep";
import VaultKeepModal from "./VaultKeepModal.vue";


defineProps({
  keptKeep: { type: KeptKeep, required: true }
})

</script>


<template>
  <div>
    <div :style="{ backgroundImage: `url(${keptKeep.img})` }" class="kept-card">
      <div class="kept-info">
        <h5 class="text-uppercase" data-bs-toggle="modal" data-bs-target="#vaultKeepModal">{{ keptKeep.name }}</h5>
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