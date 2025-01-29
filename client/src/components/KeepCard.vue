<script setup>
import { AppState } from "@/AppState";
import { Keep } from "@/models/Keep";
import { computed } from "vue";
import Pop from "@/utils/Pop";
import { logger } from "@/utils/Logger";
import { keepsService } from "@/services/KeepsService";

const props = defineProps({
  keep: { type: Keep, required: true }
})

const account = computed(() => AppState.account)


async function getKeepById(keepId) {
  try {
    await keepsService.getKeepById(keepId)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

async function deleteKeep(keepId) {
  try {
    const yes = await Pop.confirm(`Are you sure you want to delete the ${props.keep.name} keep?`)
    if (!yes) return
    await keepsService.deleteKeep(keepId)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}
</script>


<template>
  <div :style="{ backgroundImage: `url(${keep.img})` }" class="picture-img">
    <div v-if="keep.creatorId == account?.id" class="text-end">
      <button @click="deleteKeep(keep.id)" class="btn btn-small" type="button" title="Delete Keep">
        <i class="mdi mdi-close-circle text-danger"></i>
      </button>
    </div>
    <div class="keep-info d-flex justify-content-between align-items-center p-3">
      <span @click="getKeepById(keep.id)" class="fs-3" data-bs-toggle="modal" data-bs-target="#keepModal" role="button"
        :title="'See details of ' + keep.name">
        {{ keep.name }}
      </span>
      <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
        <img :src="keep.creator.picture" :alt="'A picture of' + keep.creator.name" class="creator-img"
          :title="keep.creator.name">
      </router-link>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.picture-img {
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
  aspect-ratio: 1/1;
  border: 1px solid rgb(100, 97, 97);
}

.keep-info {
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
}

span {
  text-shadow: 1px 1.2px rgb(61, 59, 59);
  font-weight: 500;
  color: rgb(238, 233, 233);
}
</style>