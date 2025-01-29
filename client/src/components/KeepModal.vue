<script setup>
import { AppState } from "@/AppState";
import { vaultKeepsService } from "@/services/VaultKeepsService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { Modal } from "bootstrap";
import { computed, ref } from "vue";


const account = computed(() => AppState.account)
const keep = computed(() => AppState.activeKeep)
const myVaults = computed(() => AppState.vaults)

const editableVaultKeepData = ref({
  vaultId: '',
  keepId: ''
})

async function createVaultKeep(keepId) {
  try {
    editableVaultKeepData.value.keepId = keep.value.id
    await vaultKeepsService.createVaultKeep(editableVaultKeepData.value)
    editableVaultKeepData.value = {
      vaultId: '',
      keepId: ''
    }
    Modal.getInstance('#keepModal').hide()
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
        <div class="modal-body">
          <div v-if="keep" class="container">
            <div class="row justify-content-between">
              <div class="col-md-6">
                <div>
                  <img :src="keep.img" :alt="'A picture by ' + keep.creator" class="keep-img">
                </div>
              </div>
              <div class="col-md-6 d-flex flex-column justify-space-around">
                <div class="text-center mt-3">
                  <i class="mdi mdi-eye fs-5" title="View count">{{ keep.views }}</i>
                  <i class="mdi mdi-alpha-k-box-outline fs-5 ms-3" title="Kept count"> {{ keep.kept }}</i>
                </div>
                <div>
                  <div class="text-center mt-md-5">
                    <h2 id="keepModalLabel">{{ keep.name }}</h2>
                  </div>
                  <div class="text-center mt-md-5 mt-3 p-2">
                    <p>{{ keep.description }}</p>
                  </div>
                </div>
                <div class="d-flex align-items-center justify-content-center mt-md-5">
                  <form v-if="account" @submit.prevent="createVaultKeep(keep.id)">
                    <div class="d-flex gap-3">
                      <select v-model="editableVaultKeepData.vaultId" class="form-select" role="button"
                        aria-label="Select a vault" required>
                        <option selected value="" disabled>Choose a vault</option>
                        <option v-for="vault in myVaults" :key="'keepModal' + vault.id" :value="vault.id"
                          class="text-uppercase" role="button">{{ vault.name }}</option>
                      </select>
                      <div>
                        <button class="btn btn-small save-button me-3" type="submit" title="Save to vault">Save</button>
                      </div>
                    </div>
                  </form>
                  <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
                    <img :src="keep.creator.picture" :alt="'A picture of ' + keep.creator.name"
                      :title="keep.creator.name" class="creator-img me-2" data-bs-dismiss="modal">
                    <span class="text-dark">{{ keep.creator.name }}</span>
                  </router-link>
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
.keep-img {
  height: 550px;
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

.keep-info {
  position: absolute;
  bottom: 0;
}

.save-button {
  background-color: rgb(146, 118, 146);
  color: white;
}
</style>