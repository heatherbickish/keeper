<script setup>
import { AppState } from "@/AppState";
import KeepCard from "@/components/KeepCard.vue";
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
        <div v-for="keep in keeps" :key="keep.id" class="mb-3">
          <KeepCard :keep="keep" />
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
    height: auto;
  }
}

@media screen and (max-width:768px) {
  .masonry-container {
    columns: 2;
  }
}
</style>
