<script setup>
import { AppState } from "@/AppState";
import { computed } from "vue";



const keep = computed(() => AppState.activeKeep)
const vaults = computed(() => AppState.vaults.filter(vault => vault.creatorId != AppState.account?.id))

</script>


<template>
  <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <!-- <div class="modal-header">
          <h1 class="modal-title fs-5" id="keepModalLabel">Modal title</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div> -->
        <div class="modal-body" id="keepModalLabel">
          <div v-if="keep">
            <div class="d-flex">
              <img :src="keep.img" :alt="'A picture by ' + keep.creator" class="keep-img">
              <div class="text-center p-4 mb-5">
                <i class="mdi mdi-eye fs-5">{{ keep.views }}</i>
                <i class="mdi mdi-alpha-k-box-outline fs-5 ms-3"> {{ keep.kept }}</i>
                <div class="p-3 mt-5">
                  <h2 class="text-center">{{ keep.name }}</h2>
                  <p>{{ keep.description }}</p>
                </div>
                <div class="d-flex justify-content-between align-items-center">

                  <!-- TODO create vaultkeep -->
                  <!-- <form>
                    <div>
                      <select class="form-select" aria-label="Select a vault" required>
                        <option value="" disabled>Choose a vault</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                      </select>
                    </div>
                  </form> -->
                  <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
                    <img :src="keep.creator.picture" :alt="'A picture of ' + keep.creator.name" class="creator-img"
                      data-bs-dismiss="modal">
                  </router-link>
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