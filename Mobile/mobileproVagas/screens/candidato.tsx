import { StackScreenProps } from '@react-navigation/stack';
import React from 'react';
import { StyleSheet, Text, View, Image, FlatList } from 'react-native';
import { TouchableOpacity } from 'react-native-gesture-handler';
import { RootStackParamList } from '../types';

export default function Candidato( {
    navigation,
}:StackScreenProps<RootStackParamList, 'NotFound'>){


  const dados:any = [
    {key: 'Desenvolvedor Back End',
      empresa:'BRQ Soluções em Informatica S.A',
      tech:'C#, Oracle, SQL Server, Azure, Angular'},
      {key: 'Desenvolvedor FrontEnd',
      empresa:'BRQ Soluções em Informatica S.A',
      tech:'Java, Java Script, React, React Native'},
      {key: 'Desenvolvedor FullStack',
      empresa:'BRQ Soluções em Informatica S.A',
      tech:'NoSQL, SQL, Node.js, JavaScript, CSS, API'},
      {key: 'Analista de Banco de Dados Jr.',
      empresa:'Hexagon | Brasil',
      tech:'• NET , Oracle, SQL Server, PL/SQL'},
      {key: 'Desenvolvedor Back End ',
      empresa:'Avanade',
      tech:'C#, Oracle, SQL Server, Azure, Angular'},
  ]

  return (
    <View style={styles.container}>
      <View style={styles.header}>
        <View style={styles.headerIcons}>
          <Image style={styles.logoSenai}
          source={require('../assets/images/senai.png')}
          />
          <Image style={styles.logoProVagas}
          source={require('../assets/images/provagas.png')}
          />
          <TouchableOpacity style={styles.btnLogout}
          onPress={ () =>navigation.navigate('Inicio') }>
            <Text style={styles.textBtnLogout}>Logout</Text>
          </TouchableOpacity>
        </View>
      </View>

      <View style={styles.MainVagas}>
        <Text style={styles.Titulos}> Minhas Inscrições </Text>
      </View>

      <View style={styles.ListaDeVagas}>
      
      <FlatList
          data={dados}
          renderItem={({ item }) => {
            return (
              <View style={styles.item}>
                <Text style={styles.text}>{item.key} </Text>
                <Text style={styles.text}>{item.empresa}</Text>
                <Text style={styles.text}>{item.tech}</Text>
              </View>
            );
          }}
        />

      </View>


    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
  header: {
    height: '10%',
    backgroundColor: '#ED1F24',
    alignItems: 'center',
    justifyContent:'space-between',
    flexDirection: 'row',
    flexWrap: 'wrap'
  },
  headerIcons:{
    width:'90%',
    marginStart:'4%',
    alignItems: 'center',
    justifyContent:'space-between',
    flexDirection: 'row',
    flexWrap: 'wrap'
  },
  logoSenai: {
    width: 80,
    height:20,
  },
  logoProVagas: {
    width:100,
    height:22,
  },
  logout:{
    width:30,
    height:30,
  },
  MainVagas:{
    alignItems: "center",
    justifyContent:'center',
    marginTop:50,
    marginBottom:40
  },
  Titulos:{
    fontSize:30
  },
  textoItem:{
    fontSize: 20,
    color:'#34495e',
    padding:25,
    borderBottomWidth:1,
    borderColor:'#ccc'

  },
  item: {
    //alignItems: "center",
    flexGrow: 1,
    margin: 10,
    padding: 20,
    borderWidth:1,
    borderRadius:5,
    borderColor:'#ccc', 
    marginLeft:'10%',
    marginRight:'10%',
    height:100,
    shadowColor: "#000",
    shadowOffset: {
        width: 0,
        height: 6,
    },
    shadowOpacity: 0.39,
    shadowRadius: 8.30,

    elevation: 13,
    
  },
  text: {
    color: "#333333"
  },
  ListaDeVagas:{

  },
  btnLogout:{
    width:35,
    height:30,
    backgroundColor:'#fff',
    borderRadius:10,
    shadowColor: "#000",
    shadowOffset: {
        width: 0,
        height: 6,
    },
    shadowOpacity: 0.39,
    shadowRadius: 8.30,

    elevation: 13,
    alignItems:'center',
    justifyContent:'center',

  },
  textBtnLogout:{
    fontSize:10,
    alignItems:'baseline',
    justifyContent:'center',
  }
});
