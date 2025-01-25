<script setup>
import { AppState } from "@/AppState";
import { Keep } from "@/models/Keep";
import { computed } from "vue";
import KeepModal from "./KeepModal.vue";

defineProps({
  keep: { type: Keep, required: true }
})

const account = computed(() => AppState.account)
</script>


<template>
  <div :style="{ backgroundImage: `url(${keep.img})` }" class="picture-img">
    <div v-if="keep.creatorId == account?.id" class="text-end">
      <button class="btn btn-small" type="button" title="Delete Keep">
        <i class="mdi mdi-close-circle text-danger"></i>
      </button>
    </div>
    <div class="keep-info d-flex justify-content-between align-items-center p-3">
      <h4 data-bs-toggle="modal" data-bs-target="#keepModal" role="button">{{ keep.name }}</h4>
      <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
        <img :src="keep.creator.picture" :alt="'A picture of' + keep.creator.name" class="creator-img">
      </router-link>
    </div>
    <KeepModal />
  </div>
</template>


<style lang="scss" scoped>
.picture-img {
  height: auto;
  width: 100%;
  border-radius: 12px;
  background-size: cover;
  background-position: center;
  box-shadow: 0 5px 8px rgba(0, 0, 0, 0.2), 5px 6px 4px rgba(0, 0, 0, 0.16);
  aspect-ratio: 1;
  position: relative;
}

.creator-img {
  height: 2.5rem;
  border-radius: 50%;
  border: 1px solid rgb(100, 97, 97);
}

.keep-info {
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
}

h4 {
  text-shadow: 1.3px 1.4px rgb(61, 59, 59);
  font-weight: 600;
  color: rgb(238, 233, 233);
}
</style>