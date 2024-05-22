import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const ProductList = () => {
  const [products, setProducts] = useState([]);
  const [userRole, setUserRole] = useState('');
  const [formData, setFormData] = useState({
    id: '',
    name: '',
    price: ''
  });
  const [isEditing, setIsEditing] = useState(false);

  const navigate = useNavigate();

  useEffect(() => {
    const token = localStorage.getItem('token');
    if (!token) {
      navigate('/');
    } else {
      fetchProductList();
      fetchUserRole();
    }
  },[]);

  const fetchProductList = async () => {
    const token = localStorage.getItem('token');
    try {
      const response = await axios.get('http://localhost:5067/api/Product', {
        headers: {
          'Authorization': `Bearer ${token}`,
        },
      });
      console.log("response : Product List data  : " + response.data);
      if (response.status === 200) {
        setProducts(response.data);
      } else {
        throw new Error('Failed to fetch product list. Check your authorization.');
      }
    } catch (error) {
      console.error(error);
      navigate('/');
    }
  };

  const fetchUserRole = () => {
    const token = localStorage.getItem('token');
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      console.log("payload fetched from token : " + payload.role);
      setUserRole(payload.role);
    } catch (error) {
      console.error(error);
      navigate('/');
    }
  };

  const deleteProduct = async (id) => {
    const token = localStorage.getItem('token');

    try {
      await axios.delete(`http://localhost:5067/api/Product/${id}`, {
        headers: {
          'Authorization': `Bearer ${token}`,
        },
      });

      fetchProductList();
    } catch (error) {
      console.error(error);
      navigate('/');
    }
  };

  const handleFormChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value
    });
  };

  const handleAddProduct = async () => {
    const token = localStorage.getItem('token');

    if (!formData.name || !formData.price) {
      alert('Name and Price are required');
      return;
    }

    try {
      await axios.post('http://localhost:5067/api/Product', formData, {
        headers: {
          'Authorization': `Bearer ${token}`,
          'Content-Type': 'application/json',
        },
      });

      setFormData({
        id: '',
        name: '',
        price: '',
        
      });
      fetchProductList();
    } catch (error) {
      console.error(error);
      navigate('/');
    }
  };

  const handleEditProduct = async () => {
    const token = localStorage.getItem('token');

    if (!formData.name || !formData.price) {
      alert('Name and Price are required');
      return;
    }

    try {
      await axios.put(`http://localhost:5067/api/Product/${formData.id}`, formData, {
        headers: {
          'Authorization': `Bearer ${token}`,
          'Content-Type': 'application/json',
        },
      });

      setFormData({
        id: '',
        name: '',
        price: '',
        
      });
      setIsEditing(false);
      fetchProductList();
    } catch (error) {
      console.error(error);
      navigate('/login');
    }
  };

  const handleEditButtonClick = (product) => {
    setFormData(product);
    setIsEditing(true);
  };

  return (
    <div>
      {userRole === 'Admin' && (
        <div className="product-form">
          <h2>{isEditing ? 'Edit Product' : 'Add Product'}</h2>
          <div>
            <input 
              type="text" 
              name="name" 
              placeholder="Name" 
              value={formData.name} 
              onChange={handleFormChange} 
            />
            
            <input 
              type="number" 
              name="price" 
              placeholder="Price" 
              value={formData.price} 
              onChange={handleFormChange} 
            />
            
            <button 
              onClick={isEditing ? handleEditProduct : handleAddProduct}
            >
              {isEditing ? 'Update Product' : 'Add Product'}
            </button>
          </div>
        </div>
      )}
      <h2 className="text-center">Product List</h2>
      <table className="table table-striped">
        <thead>
          <tr>
            <th>Name</th>
            
            <th>Price</th>
            
            {userRole === 'Admin' && <th>Action</th>}
          </tr>
        </thead>
        <tbody>
          {products.map(product => (
            <tr key={product.id}>
              <td>{product.name}</td>
              <td>{product.price}</td>
              {userRole === 'Admin' && (
                <td>
                  <button className="btn btn-danger me-2" onClick={() => deleteProduct(product.id)}>Delete</button>
                  <button className="btn btn-warning" onClick={() => handleEditButtonClick(product)}>Edit</button>
                </td>
              )}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ProductList;
