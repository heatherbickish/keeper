<script setup>
import { AppState } from "@/AppState";
import { computed } from "vue";



const keep = computed(() => AppState.activeKeep)

</script>


<template>
  <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <!-- <div class="modal-header">
          <h1 class="modal-title fs-5" id="keepModalLabel">Modal title</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div> -->
        <div class="modal-body p-0" id="keepModalLabel">
          <div v-if="keep">
            <div class="d-flex">
              <img :src="keep.img" :alt="'A picture by ' + keep.creator" class="keep-img">
              <div class="text-center p-4 mb-5">
                <i class="mdi mdi-eye fs-5"> 322</i>
                <i class="mdi mdi-alpha-k-box-outline fs-5 ms-3"> 75</i>
                <div class="p-3 mt-5">
                  <h2 class="text-center">{{ keep.name }}</h2>
                  <p>{{ keep.description }}</p>
                </div>
                <div class="d-flex justify-content-between align-items-center">

                  <!-- TODO vault select -->
                  <h5>Plants</h5>
                  <img :src="keep.creator.picture" :alt="'A picture of ' + keep.creator.name" class="creator-img">
                </div>
              </div>
              <div>
              </div>
            </div>
          </div>
        </div>
        <!-- <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary">Save changes</button>
        </div> -->
      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped>
.keep-img {
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

.keep-info {
  position: absolute;
  bottom: 0;
  // left: 0;
  // right: 0;
}
</style>