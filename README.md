# HMS project
In response to the challenges posed by the existing manual systems in Sri Lankan government hospitals, this project proposes a Hospital Management System (HMS) developed using C# and MySQL database technologies. The system is designed to address inefficiencies in patient management, reduce administrative burdens, and enhance overall healthcare services.
The HMS features a patient registration system that assigns a unique identification number to each new patient, ensuring a streamlined and efficient patient tracking process. Doctors have access to a comprehensive electronic health records system, allowing them to access and update patient medical histories, including comments, allergies, and details of previous operations.
A key feature of the system is the prescription records module, ensuring that doctors can seamlessly update medication information during each patient visit. This not only facilitates accurate prescription management but also enables timely access to critical patient data.
The prescription workflow allows doctors to select medicines and electronically send prescriptions to pharmacists, eliminating delays and enhancing collaboration between healthcare professionals. Pharmacists, in turn, can efficiently manage medicine inventory, ensuring the availability of required medications.
The proposed Hospital Management System aims to overcome the limitations of the current manual system, which often results in unnecessary time wastage for patients, data-related issues for administrative staff, and difficulties for doctors in obtaining timely and updated patient information. By embracing digital technology, this system seeks to improve the overall patient experience, reduce data-related challenges, and enhance the efficiency of healthcare delivery in Sri Lankan government hospitals.

## AIM AND OBJECTIVES
In response to these challenges, this project aims to develop and implement a comprehensive Hospital Management System that addresses the specific needs of Sri Lankan government hospitals. The primary objectives of the HMS are to:
* **Streamline patient registration and tracking:** Implement an efficient patient registration system that assigns unique identification numbers, facilitating seamless patient tracking and record management.
* **Immediate response on searching data:** The end user can search for the patient records easily by only input some criteria such as the patient ID or the patient name instead of search the patient record from a hundred or thousands of patient record from the cabinet. The system will immediately respond to the user with the patient information base on the criteria and it definitely can save up a lot of time and work on searching.
* **Establish a centralized electronic health record system:** Create a centralized electronic health records system that enables doctors to access and update patient medical histories, including comments, allergies, and details of previous operations, promoting informed treatment decisions and improved patient outcomes.
* **Automate prescription management:** Implement an electronic prescription management system that allows doctors to seamlessly prescribe medications and send them directly to pharmacists, reducing delays and enhancing medication safety.
* **Optimize inventory management:** Develop a real-time inventory management system that tracks usage and replenishment of medical supplies, ensuring the availability of essential medications and preventing stockouts.

## SIGNIFICANCE OF THE PROJECT
The implementation of the proposed HMS is expected to yield significant benefits for Sri Lankan government hospitals, including:
* **Enhanced patient care:** Improved patient experience, reduced wait times, and timely access to comprehensive medical records will contribute to enhanced patient care and satisfaction.

* **Improved administrative efficiency:** Streamlined patient registration, automated prescription management, and real-time inventory management will significantly reduce administrative burdens and free up staff time for patient care.

* **Data integrity and accessibility:** Centralized electronic records will ensure data integrity, eliminate data loss, and provide easy accessibility for authorized personnel.

* ** Informed decision-making:** Timely access to comprehensive patient data will empower doctors to make informed treatment decisions, improving patient outcomes.

* **Optimized resource utilization:** Real-time inventory management will prevent stockouts and optimize resource utilization, reducing costs and ensuring the availability of essential medications.

## INTERFACES

### Home Form
The homepage of my software is designed to be user-friendly and efficient. The three main buttons – Search Patient, New Patient, and Login – are clearly labeled and easy to find. Clicking on a button will take you to the corresponding form.
![image](https://github.com/nimeshkavindu/Hospital-Management-System-project/assets/124415338/24e3d5aa-7bae-43f3-ae89-6cd0a09c9917)

### Patient Form
In the Patient form new patients can register by providing their basic information, and upon successful registration, they will receive a unique patient ID. This ID is important for future appointments and communication with the hospital. Once registered, patients can conveniently schedule an appointment to meet a doctor of their choice directly through the form ad patient will receive an appointment number through system.
![image](https://github.com/nimeshkavindu/Hospital-Management-System-project/assets/124415338/4b7a1cba-79ab-48a6-9eeb-1ef6cbd42646)

### Search Patient Form
The search patient form lets you find patients quickly and easily, using either their name or NIC number. Just a few keystrokes and you'll have a list of potential matches. But to delve deeper and see a patient's full details, you'll need to be logged in as a doctor. This ensures patient privacy and protects sensitive medical information.
![image](https://github.com/nimeshkavindu/Hospital-Management-System-project/assets/124415338/673fd6fc-64db-4513-8d7d-2f3278526ac6)

### Login Form
Enter your username, and the system intuitively directs you to the corresponding form based on your role. New users can navigate to the Signup Page by clicking the signup button.
![image](https://github.com/nimeshkavindu/Hospital-Management-System-project/assets/124415338/3df4b45f-b6d9-4ea3-9e70-1ab9d3f10cbf)

### Signup Form
Simply input your full name, choose a unique username, set a secure password, and specify your role. With just a click on the signup button, your registration request is sent to the administrator for approval. This ensures a secure and controlled onboarding process, maintaining the integrity and privacy of our healthcare platform.
![image](https://github.com/nimeshkavindu/Hospital-Management-System-project/assets/124415338/3e6acf77-9d22-476b-aa62-965bd1c59ee9)

### Doctor Form
The Doctor Form provides a streamlined and efficient interface for medical professionals to manage appointments and prescribe medications. Located on the right side of the window, the appointment section displays a comprehensive list of scheduled appointments for the doctor. By clicking on a specific appointment, the form dynamically loads the patient's details, enabling the doctor to access crucial information.
One of the key features of the Doctor Form is the prescription functionality. Through a user-friendly interface, doctors can seamlessly add medications to the prescription by selecting drugs from a dropdown menu. This dropdown menu, known as a combobox, is directly connected to the drug inventory database, ensuring accurate and up-to-date medication options.
Once the doctor has curated the prescription, they can effortlessly send it directly to the pharmacy.
![image](https://github.com/nimeshkavindu/Hospital-Management-System-project/assets/124415338/c9484ac8-dbd9-4b55-966d-93bf9931142e)

### Pharmacist Form
The Pharmacist Form offers a comprehensive tool for pharmacists to efficiently manage prescription dispensing and inventory control. Positioned on the right side of the window, the form displays received prescriptions from doctors. Upon selecting a prescription, patient details and the prescribed medications are instantly loaded, allowing pharmacists to seamlessly access relevant information.
A pivotal feature of the Pharmacist Form is the dispensing functionality. Pharmacists can effortlessly dispense drugs in the required amounts, with the dispensed quantities automatically deducted from the inventory. The form also maintains a record of dispensed drugs, creating a dispensed drugs list for accurate tracking.
In instances where a particular drug is unavailable in the inventory or the required quantity is insufficient, the Pharmacist Form automatically adds the drug to the "Drugs to Purchase" list. This ensures that the pharmacy stays well-stocked and can meet patient needs promptly.
To facilitate record-keeping and communication, the Pharmacist Form allows pharmacists to print various documents. This includes printed prescriptions for patients, detailed records of dispensed drugs, and a list of drugs to be purchased. 
![image](https://github.com/nimeshkavindu/Hospital-Management-System-project/assets/124415338/43664448-9940-4005-8505-ce4003d0b33a)

### Drug inventory management form

![image](https://github.com/nimeshkavindu/Hospital-Management-System-project/assets/124415338/b62c0585-be0f-4ed0-9c67-4d83809cf95d)

### User management form

![image](https://github.com/nimeshkavindu/Hospital-Management-System-project/assets/124415338/4628ffeb-d7b2-4f46-bfb1-ad0b3debd113)

### View more patient details form

![image](https://github.com/nimeshkavindu/Hospital-Management-System-project/assets/124415338/9152a742-55e3-41b5-9cc3-67ad826c060c)






