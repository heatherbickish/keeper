<script setup>
import { AppState } from "@/AppState";
import { accountService } from "@/services/AccountService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { Modal } from "bootstrap";
import { computed, onMounted, ref } from "vue";

onMounted(() => editableAccountData.value = { ...account.value })

const account = computed(() => AppState.account)

const editableAccountData = ref({
  name: '',
  picture: '',
  coverImg: ''
})

async function updateAccount() {
  try {
    await accountService.updateAccount(editableAccountData.value)
    Modal.getInstance('#editAccountModal').hide()
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

</script>


<template>
  <form @submit.prevent="updateAccount()">
    <div class="mb-3">
      <label for="name" class="form-label">Your name</label>
      <input v-model="editableAccountData.name" type="name" class="form-control" id="name" placeholder="Your name..."
        maxlength="255" required>
    </div>
    <div class="mb-3">
      <label for="picture" class="form-label">Picture Url</label>
      <input v-model="editableAccountData.picture" type="url" class="form-control" id="picture"
        placeholder="Picture Url..." max="255" required>
    </div>
    <div class="mb-3">
      <label for="coverImg" class="form-label">Cover Image Url</label>
      <input v-model="editableAccountData.coverImg" type="name" class="form-control" id="coverImg"
        placeholder="Cover Image Url..." max="1000" required>
    </div>
    <div class="text-end">
      <button class="btn" type="submit" title="Save Changes">Save Changes</button>
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