<script setup>
import { AppState } from "@/AppState";
import { keepsService } from "@/services/KeepsService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { computed, onMounted } from "vue";

const keeps = computed(() => AppState.keeps)
const account = computed(() => AppState.account)

onMounted(() => {
  getAllKeeps()
})

async function getAllKeeps() {
  try {
    await keepsService.getAllKeeps()
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

</script>

<template>
  <section class="container mt-5">
    <div class="col-md-12">
      <div class="masonry-container">
        <div v-for="keep in keeps" :key="keep.id" class="mb-3 mx-2">
          <div :style="{ backgroundImage: `url(${keep.img})` }" class="picture-img">
            <div class="keep-info d-flex justify-content-between align-items-center p-3">
              <h4>{{ keep.name }}</h4>
              <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
                <img :src="keep.creator.picture" :alt="'A picture of' + keep.creator.name" class="creator-img">
              </router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
.masonry-container {
  columns: 250px;

  >* {
    break-inside: avoid;
    display: inline-block;
    width: 100%;
  }
}

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
  border: 1px solid rgb(75, 72, 72);
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
