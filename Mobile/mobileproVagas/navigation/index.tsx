import { NavigationContainer, DefaultTheme, DarkTheme } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import * as React from 'react';
import { ColorSchemeName } from 'react-native';

import SplashScreen from '../screens/splash';
import LoginScreen from '../screens/login';
import InicioScreen from '../screens/inicioScreen';
import NotFoundScreen from '../screens/notfound'
import DashBoardScreen from '../screens/dashboarduser';
import TipoScreen from '../screens/tipouser';
import LoginEmpresaScreen from '../screens/loginempresa';
import Candidato from'../screens/candidato';
import Empresa from '../screens/empresa';
import { RootStackParamList } from '../types';
import LinkingConfiguration from './LinkingConfiguration';

// If you are not familiar with React Navigation, we recommend going through the
// "Fundamentals" guide: https://reactnavigation.org/docs/getting-started
export default function Navigation({ colorScheme }: { colorScheme: ColorSchemeName }) {
  return (
    <NavigationContainer
      linking={LinkingConfiguration}
      theme={colorScheme === 'dark' ? DarkTheme : DefaultTheme}>
      <RootNavigator />
    </NavigationContainer>
  );
}

// A root stack navigator is often used for displaying modals on top of all other content
// Read more here: https://reactnavigation.org/docs/modal
const Stack = createStackNavigator<RootStackParamList>();

function RootNavigator() {
  return (
    <Stack.Navigator screenOptions={{ headerShown: false }}>
      <Stack.Screen name="Splash" component={SplashScreen} options={{ title: 'Splash' }} />
      <Stack.Screen name="Tipo" component={TipoScreen} options={{ title: 'Tipo de Usuario' }} />
      <Stack.Screen name="Inicio" component={InicioScreen} options={{ title: 'Inicio' }} />
      <Stack.Screen name="Login" component={LoginScreen} options={{ title: 'Login' }} />
      <Stack.Screen name="LoginEmpresa" component={LoginEmpresaScreen} options={{ title: 'Login' }} />
      <Stack.Screen name="dashboarduser" component={DashBoardScreen} options={{ title: 'Dashboard' }} />
      <Stack.Screen name="NotFound" component={NotFoundScreen} options={{ title: 'NotFound' }} />
      <Stack.Screen name="Candidato" component={Candidato} options={{ title: 'Candidato' }} />
      <Stack.Screen name="Empresa" component={Empresa} options={{ title: 'Empresa' }} />

    </Stack.Navigator>
  );
}
