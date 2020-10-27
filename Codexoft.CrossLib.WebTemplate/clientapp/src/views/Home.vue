<template>
    <div class="home">
        <label>
            <input type="text" v-model="credentials.email">
        </label>
        <button type="button" v-on:click="callClick">Call</button>
        <img alt="Vue logo" src="../assets/logo.png">
        <HelloWorld msg="Welcome to Your Vue.js + TypeScript App for Desktop Version" />
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator'
    import HelloWorld from '@/components/HelloWorld.vue'
    import { LoginModel } from '@/data/Models/loginModel'
    import { Login } from '@/object-builder'
    @Component({
        components: {
            HelloWorld,
        },
    })
    export default class Home extends Vue {
        credentials: LoginModel = new Login()

        callClick() {
            alert(this.credentials.email)
        }
    }
</script>
