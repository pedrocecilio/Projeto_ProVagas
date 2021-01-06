import { StackScreenProps } from '@react-navigation/stack';
import React from 'react';
import { View, Image, StyleSheet, Text, TouchableOpacity  } from 'react-native';
import { RootStackParamList } from '../types';

export default function Inicio({
    navigation,
  }: StackScreenProps<RootStackParamList, 'NotFound'>){


  
    return (
        <View >
          <View style={styles.container}>

          </View>
            <View style={styles.card}>
                <View  style={styles.center}>

                <Text style={{fontWeight:"bold",fontSize:18}}>
                    Bem Vindo ao ProVagas !
                </Text>
                </View>
                 <View  style={styles.slogan}>

                <Text >
                    Pensado para empresas, pensado para candidatos !
                </Text>
                </View>


                <View >
                <Image
                   style={{ width: 260, height: 150, marginBottom: '15%',marginLeft:7, marginTop: 50, justifyContent: 'center', alignItems: 'center'}}
                   source={require('../assets/images/work.png')}

                />
                </View>

                    <TouchableOpacity
                     style={styles.btnEntar}
                    onPress={ () => navigation.replace('Tipo') }
                      >
                     <Text style={styles.textBtnEntrar}>Entrar</Text>
                    </TouchableOpacity>
            </View>
    
        </View>
      );
    
}

const styles = StyleSheet.create({
  
    container: {
      flex: 2,
    backgroundColor: '#ED1F24',
    alignItems: 'center',
    justifyContent: 'center',
    padding: 10,
    paddingTop: 200
     } ,
     card:{
        height:570,
        width:"87%",
        alignItems: 'center',
        justifyContent: 'center',
        backgroundColor:"white",
        borderRadius:15,
        elevation:10,
        padding:10,
        marginTop: -80,
        marginLeft: 25
      },
      center: {
        alignItems: 'center',
        justifyContent: 'center',
        padding: 20
        
      },
      slogan: {
          alignItems: 'center',
          justifyContent: 'center',
          padding: 24,    
           
      },
    
      btnEntar:
      {
        width:180,
        height: 40,
        backgroundColor: "#ED1F24",
        marginTop: 60,
        marginLeft: 10,
        borderRadius: 4,
        alignItems: 'center',
        justifyContent: 'center',
      
      },

      textBtnEntrar: {
        fontSize: 12,
        color: "#fff",
        fontWeight: "bold"
      }

    });