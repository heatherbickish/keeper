<script setup>
import { keepsService } from "@/services/KeepsService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { Modal } from "bootstrap";
import { ref } from "vue";



const editableKeepData = ref({
  name: '',
  img: '',
  description: ''
})

async function createKeep() {
  try {
    await keepsService.createKeep(editableKeepData.value)
    editableKeepData.value = {
      name: '',
      img: '',
      description: ''
    }
    Modal.getInstance('#newKeepModal').hide()
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

</script>


<template>
  <form @submit.prevent="createKeep()">
    <div class="mb-3">
      <input v-model="editableKeepData.name" type="text" class="form-control" id="name" placeholder="Title..."
        maxlength="255" required>
    </div>
    <div class="mb-4">
      <input v-model="editableKeepData.img" type="url" class="form-control" id="img" placeholder="Image Url..."
        max="1000" required>
    </div>
    <div class="mb-3">
      <textarea v-model="editableKeepData.description" class="form-control" id="description" rows="3"
        placeholder="Keep Description..." maxlength="1000" required></textarea>
    </div>
    <div class="text-end">
      <button class="btn" type="submit" title="Create Keep">Create</button>
    </div>
  </form>
</template>


<style lang="scss" scoped>
input,
textarea {
  border: none;
  border-bottom: 1px solid #c3c8db;
}

button {
  background-color: #1b1b1b;
  color: white;
}
</style>