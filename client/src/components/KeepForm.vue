<script setup>

</script>


<template>
  <form>
    <div class="mb-3">
      <input type="text" class="form-control" id="name" placeholder="Title..." maxlength="255" required>
    </div>
    <div class="mb-4">
      <input type="url" class="form-control" id="img" placeholder="Image Url..." max="1000" required>
    </div>
    <div class="mb-3">
      <textarea class="form-control" id="description" rows="3" placeholder="Keep Description..." maxlength="1000"
        required></textarea>
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