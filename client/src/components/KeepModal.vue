<script setup>
import { AppState } from "@/AppState";
import { keepsService } from "@/services/KeepsService";
import { vaultKeepsService } from "@/services/VaultKeepsService";
import { vaultsService } from "@/services/VaultsService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { computed, onMounted, ref } from "vue";



const keep = computed(() => AppState.activeKeep)
const myVaults = computed(() => AppState.vaults)

const editableVaultKeepData = ref(
  {
    vaultId: '',
    keepId: ''

  })

onMounted(() => {
  getMyVaults()
})

async function getMyVaults() {
  try {
    await vaultsService.getMyVaults()
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

async function createVaultKeep(keepId) {
  try {
    editableVaultKeepData.value.keepId = keep.value.id
    await vaultKeepsService.createVaultKeep(editableVaultKeepData.value)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

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
                  <form @submit.prevent="createVaultKeep(keep.id)">
                    <div class="d-flex gap-2">
                      <select v-model="editableVaultKeepData.vaultId" class="form-select" aria-label="Select a vault"
                        required>
                        <option selected value="" disabled>Choose a vault</option>
                        <option v-for="vault in myVaults" :key="'keepModal' + vault.id" :value="vault.id"
                          class="text-uppercase">{{ vault.name }}</option>
                      </select>
                      <div>
                        <button class="btn btn-small save-button" type="submit" title="Save to vault">Save</button>
                      </div>
                    </div>
                  </form>
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

.save-button {
  background-color: rgb(146, 118, 146);
  color: white;
}
</style>