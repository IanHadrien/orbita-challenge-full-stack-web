<template>
  <div class="px-6 pt-4">
    <div class="border flex items-center justify-between space-x-16">
      <v-text-field
        label="Prepend inner"
        prepend-inner-icon="mdi-map-marker"
        variant="outlined"
        rounded="lg"
        density="compact"
      />

      <RegisterStudent />
    </div>
    
    <!-- Table -->
    <v-data-table
      :headers="headers"
      :items="desserts"
      :sort-by="[{ key: 'id', order: 'asc' }]"
      :fixed-footer="{
        itemsPerPageText: 'Itens por página',
        pageText: (pageStart, pageStop, itemsLength) => 
          `${pageStart}-${pageStop} de ${itemsLength}`
      }"
    >
      <template v-slot:item.actions="{ item }">
        <UpdateStudent :student="item" />

        <DeleteStudent :student="item" />
      </template>
    </v-data-table>
  </div>
</template>

<script lang="ts">
  import RegisterStudent from './register-student.vue'
  import UpdateStudent from './update-student.vue'
  import DeleteStudent from './delete-student.vue'

  export default {
    name: "Students",

    data: () => ({
      headers: [
        { title: 'REGISTRO ACADÊMICO', align: 'start', sortable: false, key: 'ra'},
        { title: 'NOME', key: 'name' },
        { title: 'CPF', key: 'cpf' },
        { title: '', key: 'actions', align: 'center', sortable: false },
      ],

      desserts: [],
    }),

    components: {
      RegisterStudent,
      UpdateStudent,
      DeleteStudent
    },

    created () {
      this.initialize()
    },

    methods: {
      initialize () {
        this.desserts = [
          {
            id: '123123',
            name: 'teste 1',
            email: 'Ianteste@enmai.com',
            ra: '12312312323',
            cpf: '12312312323',
          },
          {
            id: '123123',
            name: 'teste 2',
            email: 'Ianteste2@enmai.com',
            ra: '12312312113',
            cpf: '12312312323',
          },
        ]
      }
    },
  }
</script>