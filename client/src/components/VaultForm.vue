<script setup>

</script>


<template>
  <form>
    <div class="mb-3">
      <input type="text" class="form-control" id="name" placeholder="Title..." maxlength="255" required>
    </div>
    <div class="mb-3">
      <input type="url" class="form-control" id="img" placeholder="URL..." max="1000" required>
    </div>
    <div id="vaultIsPrivateHelp" class="form-text text-end">Private vaults can only be seen by you</div>
    <div class="form-check d-flex justify-content-end align-items-center mb-4 gap-1">
      <input class="form-check-input" type="checkbox" value="" id="isPrivate" required>
      <label class="form-check-label" for="flexCheckDefault">
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