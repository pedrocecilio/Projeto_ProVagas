import React, { useState } from 'react';
// import api from '../services/api.js';
import jwt from 'jwt-decode';
import AssynStorage from '@react-native-async-storage/async-storage'
import {Alert, StyleSheet, Text, View, Image, TextInput, TouchableOpacity } from 'react-native';
import Navigation from '../navigation/index.js';
import { RootStackParamList } from '../types.js';
import { StackScreenProps } from '@react-navigation/stack';
import jwtDecode from 'jwt-decode';



export default function TabOneScreen({
  navigation,
}: StackScreenProps<RootStackParamList, 'NotFound'>) {

  // const[email, setEmail] = useState('');
  // const[senha, setSenha] = useState('');

  // const state = {
  //   errorMessage: null,
  // }

  // const login = async () => {

    
      // const resposta: any = await api.post('/login',{
      //   email: email,
      //   senha: senha
      // });
  
      // const token = resposta.data.token;
  
      // await AssynStorage.setItem('provagas-chave-autenticacao', token);
  
      // if(jwt(token).Role === 'Empresa') {
      //   console.log('Empresa Logada!')
      // //  navigation.navigate('NotFound')
      // }else{
      //   console.log('Candidato logado!')
      // }


  //   fetch('http://192.168.0.118:5000/api/login',{ 
  //     method: 'post',
  //     body:JSON.stringify(login),
  //     headers:{
  //       'content-type': 'application/json'
  //     }
  //   }) 
  //   .then(response => response.json())
  //   .then(data => {
  //     if (data.value.token != undefined) {
  //       localStorage.setItem('provagas-chave-autenticacao', data.value.token)
  //       if(jwtDecode( ) === 'Empresa'){
  //         navigation.navigate('NotFound')
  //       }
  //     }
  //   })

  // }
  
  return (
    <View style={styles.container}>

      <Text style={styles.titleLogin}>Olá empresa, seja bem-vinda!</Text>
        {/* { !!state.errorMessage && <Text>{state.errorMessage}</Text>} */}
      <Image 
      source={require('../assets/images/img_login.png')}
      style={styles.banner}
      />
      
      <TextInput
      style={styles.inputLogin}
      placeholder="Digite seu email.."
      // onChangeText={email => setEmail(email)}
      />
      <TextInput
      style={styles.inputLogin}
      secureTextEntry={true}
      placeholder="Digite sua senha.."
      // onChangeText={senha => setSenha(senha)}
      />
      <TouchableOpacity
        style={styles.btnLogin}
        onPress={ () =>navigation.navigate('Empresa') }
      >
      <Text style={styles.textBtnLogin}>Login</Text>
      </TouchableOpacity>
      
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: '#ffffff'
  },
  titleLogin: {
    marginBottom: 50,
    marginTop: -100,
    fontSize: 16,
    fontWeight: "bold"
  },
  banner: {
    width: 135,
    height: 135,
    marginBottom: 40,
    borderRadius: 20
  }, 
  inputLogin: {
    marginTop: 10,
    width: 300,
    fontSize: 16,
    borderRadius: 4,
    padding: 10,
    borderBottomWidth: .8,
    borderTopWidth: .8,
    borderLeftWidth: .8,
    borderRightWidth: .8
    // shadowColor: '#470000',
    // shadowOffset: {width: 0, height: 2},
    // shadowOpacity: 0.25,
    // shadowRadius: 3.84,
    // elevation: 3,
  },
  btnLogin: {
    width:300,
    height: 48,
    backgroundColor: "#ED1F24",
    marginTop: 30,
    borderRadius: 4,
    alignItems: 'center',
    justifyContent: 'center'

  },
  textBtnLogin: {
    fontSize: 16,
    color: "#fff",
    fontWeight: "bold"
  }
});