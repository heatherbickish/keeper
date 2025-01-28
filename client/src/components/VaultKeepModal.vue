<script setup>
import { AppState } from "@/AppState";
import { computed } from "vue";


const keptKeep = computed(() => AppState.activeKeep)

</script>


<template>
  <div class="modal fade" id="vaultKeepModal" tabindex="-1" aria-labelledby="vaultKeepModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <!-- <div class="modal-header">
        <h1 class="modal-title fs-5" id="vaultKeepModalLabel">Modal title</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div> -->
        <div class="modal-body" id="vaultKeepModalLabel">
          <div v-if="keptKeep">
            <div class="d-flex">
              <img :src="keptKeep.img" :alt="'A picture by ' + keptKeep.creator" class="kept-img">
              <div class="text-center p-4 mb-5">
                <i class="mdi mdi-eye fs-5">{{ keptKeep.views }}</i>
                <i class="mdi mdi-alpha-k-box-outline fs-5 ms-3"> {{ keptKeep.kept }}</i>
                <div class="p-3 mt-5">
                  <h2 class="text-center">{{ keptKeep.name }}</h2>
                  <p>{{ keptKeep.description }}</p>
                </div>
                <div class="d-flex justify-content-end">
                  <img :src="keptKeep.creator.picture" :alt="'A picture of ' + keptKeep.creator.name"
                    class="creator-img" data-bs-dismiss="modal" role="button">
                </div>
              </div>
              <div>
              </div>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn" data-bs-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.kept-img {
  height: 500px;
  width: 400px;
  object-fit: cover;
}

i {
  color: #8c8e96;
}

.creator-img {
  height: 3rem;
  border-radius: 50%;
  aspect-ratio: 1/1;
  border: 1px solid rgb(100, 97, 97);
}

.kept-info {
  position: absolute;
  bottom: 0;
  // left: 0;
  // right: 0;
}
</style>