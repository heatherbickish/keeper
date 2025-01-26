<script setup>
import VaultForm from "./VaultForm.vue";


</script>


<template>
  <!-- Button trigger modal -->
  <!-- <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#newVaultModal">
    Launch demo modal
  </button> -->

  <!-- Modal -->
  <div class="modal fade" id="newVaultModal" tabindex="-1" aria-labelledby="newVaultModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="newVaultModalLabel">Add your vault</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <VaultForm />
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
.modal-header {
  border-bottom: none;
}
</style>