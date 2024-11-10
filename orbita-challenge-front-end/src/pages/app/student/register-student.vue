<template>
  <v-dialog
    v-model="dialog"
    max-width="500px"
  >
    <template v-slot:activator="{ props }">
      <v-btn
        prepend-icon="$vuetify"
        color="primary"
        class="mb-5"
        height="40"
        border
        rounded="lg"
        dark
        v-bind="props"
      >
        Cadastrar Aluno
      </v-btn>
    </template>

    <v-card>
      <v-card-title class="border-b-2">
        <span class="text-h5">Cadastrar Aluno</span>
      </v-card-title>

      <form class="p-2 px-4 pt-5 space-y-3" @submit="registerStudent">
        <div>
          <label for="name" class="block mb-2 text-sm font-medium text-gray-900">
            Nome *
          </label>
          <input 
            type="text" 
            id="name" 
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" 
            placeholder="Informe o nome completo" 
            required 
            v-model="itensForm.name"
          />
        </div> 

        <div>
          <label for="email" class="block mb-2 text-sm font-medium text-gray-900">
            E-mail *
          </label>
          <input 
            type="email" 
            id="email" 
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" 
            placeholder="Informe apenas um e-mail"   
            required 
          />
        </div> 

        <div>
          <label for="ra" class="block mb-2 text-sm font-medium text-gray-900">
            Registro acadêmico *
          </label>
          <input 
            type="number" 
            id="ra" 
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" 
            placeholder="Informe o registro acadêmico" 
            required 
          />
        </div> 

        <div>
          <label for="cpf" class="block mb-2 text-sm font-medium text-gray-900">
            CPF *
          </label>
          <input 
            type="number" 
            id="cpf" 
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" 
            placeholder="Informe o número do documento" 
            required 
          />
        </div> 

        <div class="flex items-center justify-end space-x-2">
          <button 
            @click="close"
            type="submit" 
            class="inline-flex w-full justify-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:mt-0 sm:w-auto">
            Cancelar
          </button>
          <button 
            type="submit" 
            class="inline-flex w-full justify-center rounded-md bg-gray-900 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:opacity-80 sm:ml-3 sm:w-auto">
            Salvar
          </button>
        </div>

        <!-- <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="blue-darken-1"
            variant="text"
            @click="v$.$validate"
          >
            Save
          </v-btn>
        </v-card-actions> -->
      </form>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
  export default {
    name: 'RegisterStudent',

    data() {
      return {
        dialog: false,

        itensForm: {
          name: '',
          email: '',
          ra: '',
          cpf: '',
        },
      }
  },

    watch: {
      dialog (val) {
        val || this.close()
      },
    },

    methods: {
      registerStudent (e) {
        e.preventDefault();
        console.log('register', this.itensForm)
      },

      close () {
        this.dialog = false
      },
    }
  }
</script>

<style scoped>

</style>