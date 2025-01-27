<script setup>
import { AppState } from "@/AppState";
import { vaultsService } from "@/services/VaultsService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { Modal } from "bootstrap";
import { ref } from "vue";


const editableVaultData = ref({
  name: '',
  img: '',
  description: '',
  isPrivate: false
})

async function createVault() {
  try {
    await vaultsService.createVault(editableVaultData.value)
    editableVaultData.value = {
      name: '',
      img: '',
      description: '',
      isPrivate: false
    }
    Modal.getInstance('#newVaultModal').hide()
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

</script>


<template>
  <form @submit.prevent="createVault()">
    <div class="mb-3">
      <input v-model="editableVaultData.name" type="text" class="form-control" id="name" placeholder="Title..."
        maxlength="255" required>
    </div>
    <div class="mb-3">
      <input v-model="editableVaultData.img" type="url" class="form-control" id="img" placeholder="URL..." max="1000"
        required>
    </div>
    <div class="mb-3">
      <textarea v-model="editableVaultData.description" class="form-control" id="description" rows="3"
        placeholder="Keep Description..." maxlength="1000" required></textarea>
    </div>
    <div id="vaultIsPrivateHelp" class="form-text text-end">Private vaults can only be seen by you</div>
    <div class="form-check d-flex justify-content-end align-items-center mb-4 gap-1">
      <input v-model="editableVaultData.isPrivate" class="form-check-input" type="checkbox" value="" id="isPrivate">
      <label class="form-check-label" for="isPrivate">
        Make Vault Private?
      </label>
    </div>
    <div class="text-end me-3">
      <button class="btn" type="submit" title="Create Vault">Create Vault</button>
    </div>
  </form>
</template>


<style lang="scss" scoped>
input {
  border: none;
  border-bottom: 1px solid #c3c8db;
}

button {
  background-color: #1b1b1b;
  color: white;
}
</style>