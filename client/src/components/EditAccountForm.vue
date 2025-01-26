<script setup>

</script>


<template>
  <form>
    <div class="mb-3">
      <input type="name" class="form-control" id="name" placeholder="Your name..." maxlength="255" required>
    </div>
    <div class="mb-3">
      <input type="url" class="form-control" id="picture" placeholder="Picture Url..." max="255" required>
    </div>
    <div class="mb-3">
      <input type="name" class="form-control" id="coverImg" placeholder="Cover Image Url..." max="1000" required>
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