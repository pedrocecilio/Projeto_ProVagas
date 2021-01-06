import { StackScreenProps } from '@react-navigation/stack';
import React from 'react';
import {Alert, StyleSheet, Text, View, Image, TextInput, TouchableOpacity } from 'react-native';
import { RootStackParamList } from '../types';

export default function TipoUser({
  navigation,
}: StackScreenProps<RootStackParamList, 'NotFound'> ) {
  return (
    <View style={styles.container}>
      <Text style={styles.titlePage}>Como deseja fazer login?</Text>
      <View style={styles.container__cards}>
      <TouchableOpacity
        style={styles.btnCandidato}
        onPress={ () => navigation.navigate('Login') }
      >
      <Text style={styles.textBtnCandidato}>Candidato</Text>
      <Image 
      source={require('../assets/images/img_login.png')}
      style={styles.imgCards}
      />
      </TouchableOpacity>
      <TouchableOpacity
        style={styles.btnEmpresa}
        onPress={ () => navigation.navigate('LoginEmpresa') }
      >
      <Text style={styles.textBtnEmpresa}>Empresa</Text>
      <Image 
      source={require('../assets/images/img_login.png')}
      style={styles.imgCards}
      />
      </TouchableOpacity>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: '#fff'

  },
  container__cards: {
    flex: 0.4,
    alignItems: 'center',
    justifyContent: 'space-between',
    backgroundColor: '#fff',
    flexDirection: 'row',
    width: 325
  },
  btnCandidato: {
    width: 150,
    height: 160,
    backgroundColor: "#fff",
    marginTop: 30,
    borderRadius: 5,
    alignItems: 'center',
    justifyContent: 'center',
    padding: 10,
    borderBottomWidth: .8,
    borderTopWidth: .8,
    borderLeftWidth: .8,
    borderRightWidth: .8

  },
  textBtnCandidato: {
    fontSize: 16,
    color: "#ED1F24",
    fontWeight: "bold"
  },
  btnEmpresa: {
    width: 150,
    height: 160,
    backgroundColor: "#fff",
    marginTop: 30,
    borderRadius: 5,
    alignItems: 'center',
    justifyContent: 'center',
    padding: 10,
    borderBottomWidth: .8,
    borderTopWidth: .8,
    borderLeftWidth: .8,
    borderRightWidth: .8

  },
  textBtnEmpresa : {
    fontSize: 16,
    color: "#ED1F24",
    fontWeight: "bold"
  },
  imgCards: {
    width: 120,
    height:120
  },
  titlePage:{
    fontSize: 22
  }
});