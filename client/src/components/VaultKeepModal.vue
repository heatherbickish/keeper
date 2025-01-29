<script setup>
import { AppState } from "@/AppState";
import { computed } from "vue";


const keptKeep = computed(() => AppState.activeKeep)

</script>


<template>
  <div class="modal fade" id="vaultKeepModal" tabindex="-1" aria-labelledby="vaultKeepModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-body">
          <div v-if="keptKeep" class="container">
            <div class="row justify-content-center">
              <div class="col-md-6">
                <div>
                  <img :src="keptKeep.img" :alt="'A picture by ' + keptKeep.creator" class="kept-img">
                </div>
              </div>
              <div class="col-md-6">
                <div class="text-center mt-3">
                  <i class="mdi mdi-eye fs-5">{{ keptKeep.views }}</i>
                  <i class="mdi mdi-alpha-k-box-outline fs-5 ms-3"> {{ keptKeep.kept }}</i>
                </div>
                <div class="text-center mt-md-5" id="vaultKeepModalLabel">
                  <h2>{{ keptKeep.name }}</h2>
                </div>
                <div class="text-center mt-md-4">
                  <img :src="keptKeep.creator.picture" :alt="'A picture of ' + keptKeep.creator.name"
                    class="creator-img" :title="keptKeep.creator.name" data-bs-dismiss="modal" role="button">
                </div>
                <div class=" text-center mt-md-5 p-2">
                  <p>{{ keptKeep.description }}</p>
                </div>

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
  width: 100%;
  object-fit: cover;
}

i {
  color: #8c8e96;
}

.creator-img {
  height: 3rem;
  border-radius: 50%;
  aspect-ratio: 1/1;
  object-fit: cover;
  object-position: center;
  border: 1px solid rgb(100, 97, 97);
}

.kept-info {
  position: absolute;
  bottom: 0;
}
</style>