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
      :sort-by="[{ key: 'calories', order: 'asc' }]"
    >
      <template v-slot:top>     
        <v-dialog v-model="dialogDelete" max-width="500px">
          <v-card>
            <v-card-title class="text-h5">Are you sure you want to delete this item?</v-card-title>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue-darken-1" variant="text" @click="closeDelete">Cancel</v-btn>
              <v-btn color="blue-darken-1" variant="text" @click="deleteItemConfirm">OK</v-btn>
              <v-spacer></v-spacer>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </template>

      <template v-slot:item.actions="{ item }">
        <v-icon
          class="me-2"
          size="small"
          @click="editItem(item)"
        >
          mdi-pencil
        </v-icon>
        <v-icon
          size="small"
          @click="deleteItem(item)"
        >
          mdi-delete
        </v-icon>
      </template>
    </v-data-table>
  </div>
</template>

<script lang="ts">
  import RegisterStudent from './register-student.vue';

  export default {
    name: "Students",

    data: () => ({
      dialog: false,
      dialogDelete: false,

      headers: [
        { title: 'Registro Acadêmico', align: 'start', sortable: false, key: 'name'},
        { title: 'Nome', key: 'calories' },
        { title: 'CPF', key: 'fat' },
        { title: '', key: 'actions', sortable: false },
      ],

      desserts: [],
      editedIndex: -1,

      editedItem: {
        name: '',
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0,
      },

      defaultItem: {
        name: '',
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0,
      },
    }),

    components: {
      RegisterStudent
    },

    computed: {
      formTitle () {
        return this.editedIndex === -1 ? 'New Item' : 'Edit Item'
      },
    },

    watch: {
      dialog (val) {
        val || this.close()
      },
      dialogDelete (val) {
        val || this.closeDelete()
      },
    },

    created () {
      this.initialize()
    },

    methods: {
      initialize () {
        this.desserts = [
          {
            name: '12312312323',
            calories: 'Ian Hadrien Santos Ferreira',
            fat: 12312312323,
          },
          {
            name: '12312312323',
            calories: 'Ian Hadrien Santos Ferreira',
            fat: 12312312323,
          },
        ]
      },

      editItem (item) {
        console.log("Edited")
        // this.editedIndex = this.desserts.indexOf(item)
        // this.editedItem = Object.assign({}, item)
        // this.dialog = true
      },

      deleteItem (item) {
        // this.editedIndex = this.desserts.indexOf(item)
        // this.editedItem = Object.assign({}, item)
        // this.dialogDelete = true
        console.log("deleteItem")
      },

      deleteItemConfirm () {
        this.desserts.splice(this.editedIndex, 1)
        this.closeDelete()
      },

      close () {
        this.dialog = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      closeDelete () {
        this.dialogDelete = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      save () {
        if (this.editedIndex > -1) {
          Object.assign(this.desserts[this.editedIndex], this.editedItem)
        } else {
          this.desserts.push(this.editedItem)
        }
        this.close()
      },
    },
  }
</script>