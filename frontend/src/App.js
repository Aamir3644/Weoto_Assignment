import { Routes, Route, Navigate} from 'react-router-dom';
import SignInUpForm from './Components/SignInUpForm';
import ProductList from './Components/ProductList';
import PrivateRoute from './Components/PrivateRoute';


function App() {
  return (
    <Routes>
      <Route path="/" element={<SignInUpForm />} />
      <Route path="/login" element={<SignInUpForm />} />
      <Route path="/unauthorized" element={<h1>Unauthorized Access</h1>} />
      <Route element={<PrivateRoute allowedRoles={['Admin', 'User']} />}>
        <Route path="/products" element={<ProductList />} />
      </Route>
      <Route path="*" element={<Navigate to="/" />} />
    </Routes>
    )
}

export default App;