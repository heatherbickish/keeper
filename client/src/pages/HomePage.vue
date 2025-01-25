<script setup>
import { AppState } from "@/AppState";
import { keepsService } from "@/services/KeepsService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { computed, onMounted } from "vue";

const keeps = computed(() => AppState.keeps)

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
          <img :src="keep.img" :alt="'A picture of' + keep.name" class="picture-img rounded">
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
  }
}

.picture-img {
  width: 100%;
  box-shadow: 0 5px 8px rgba(0, 0, 0, 0.2), 5px 6px 4px rgba(0, 0, 0, 0.16);
}
</style>
