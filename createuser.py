#Kişinin yüz verilerinin alınıp sisteme kaydedildiği kısım
import cv2
# Camera Settings
cameraWidth = 1020
cameraHeight = 720

# Face Detect Class
classifierFolder = 'haarcascade_frontalface_default.xml'
face_detector = cv2.CascadeClassifier(classifierFolder)

# Face Data Folder
faceDataFolder = "Datas/FaceDatas"

# Create Camera
#camera = cv2.VideoCapture(1)
camera = cv2.VideoCapture(0,cv2.CAP_DSHOW).release()
camera=cv2.VideoCapture(0,cv2.CAP_DSHOW)

# Camera Settings Late
camera.set(3, cameraWidth)
camera.set(4, cameraHeight)

# region Face Scan Function
def FaceCapture():
    # Captured face count
    count = 0
    # Face capture process
    while True:
        ret, img = camera.read()
        img = cv2.flip(img, 1)
        gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
        faces = face_detector.detectMultiScale(gray, 1.4, 5)
        for (x, y, w, h) in faces:
            cv2.rectangle(img, (x, y), (x + w, y + h), (255, 0, 0), 2)
            count += 1
            # Save captured face to FaceData folder
            cv2.imwrite(f"{faceDataFolder}/user.{str(userToken)}.{str(count)}.jpg", gray[y:y + h, x:x + w])
            cv2.imshow('image', img)
        k = cv2.waitKey(100) & 0xff  # 'ESC' to stop capturing
        if k == 27:
            break
        elif count >= 50:  # Take 50 faces to stop capture
            break


# endregion

userID = input("User ID : ")

userToken = userID


print("Initializing face capture. Look the camera and wait..")
FaceCapture()
print("Face is captured.")


# Clean and close camera window
camera.release()
cv2.destroyAllWindows()